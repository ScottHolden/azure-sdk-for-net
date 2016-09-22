﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management;
using Microsoft.Azure.Management.V2.Resource;
using Microsoft.Azure.Management.V2.Resource.Authentication;
using Microsoft.Azure.Management.V2.Resource.Core;
using Newtonsoft.Json.Linq;
using System;

namespace Samples
{
    public static class DeployUsingArmTemplate
    {
        public static void Deploy()
        {
            try
            {
                var rgName = ResourceNamer.RandomResourceName("rgRSAT", 24);
                var deploymentName = ResourceNamer.RandomResourceName("dpRSAT", 24);

                try
                {
                    //=================================================================
                    // Authenticate

                    var tokenCredentials = new ApplicationTokenCredentials(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                    var azure = Azure
                        .Configure()
                        .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                        .Authenticate(tokenCredentials).WithSubscription(tokenCredentials.DefaultSubscriptionId);

                    try
                    {
                        var templateJson = GetTemplate();

                        //=============================================================
                        // Create resource group.

                        Console.WriteLine("Creating a resource group with name: " + rgName);

                        azure.ResourceGroups.Define(rgName)
                            .WithRegion(Region.US_WEST)
                            .Create();

                        Console.WriteLine("Created a resource group with name: " + rgName);

                        //=============================================================
                        // Create a deployment for an Azure App Service via an ARM
                        // template.

                        Console.WriteLine("Starting a deployment for an Azure App Service: " + deploymentName);

                        azure.Deployments.Define(deploymentName)
                            .WithExistingResourceGroup(rgName)
                            .WithTemplate(templateJson)
                            .WithParameters("{}")
                            .WithMode(Microsoft.Azure.Management.ResourceManager.Models.DeploymentMode.Incremental)
                            .Create();

                        Console.WriteLine("Completed the deployment: " + deploymentName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    finally
                    {
                        try
                        {
                            Console.WriteLine("Deleting Resource Group: " + rgName);
                            azure.ResourceGroups.Delete(rgName);
                            Console.WriteLine("Deleted Resource Group: " + rgName);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static string GetTemplate()
        {
            var hostingPlanName = ResourceNamer.RandomResourceName("hpRSAT", 24);
            var webAppName = ResourceNamer.RandomResourceName("wnRSAT", 24);
            var armTemplateString = System.IO.File.ReadAllText(@".\ARMTemplate\TemplateValue.json");

            var parsedTemplate = JObject.Parse(armTemplateString);
            parsedTemplate.SelectToken("parameters.hostingPlanName")["defaultValue"] = hostingPlanName;
            parsedTemplate.SelectToken("parameters.webSiteName")["defaultValue"] = webAppName;
            parsedTemplate.SelectToken("parameters.skuName")["defaultValue"] = "F1";
            parsedTemplate.SelectToken("parameters.skuCapacity")["defaultValue"] = 1;

            return parsedTemplate.ToString();
        }
    }
}