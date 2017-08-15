using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Management.EventGrid;
using Microsoft.Azure.Management.EventGrid.Models;
using Xunit;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;

namespace EventGrid.Tests
{
	public class EventSubscriptionScenarioTests
	{
		[Fact]
		public void EventSubscriptionCRUDSubscriptionScope()
		{
			using (TestContext context = new TestContext(this))
			{
				ResourceGroup resourceGroup = context.CreateResourceGroup("eg-eventsub-sub-");
				EventGridManagementClient client = context.GetClient<EventGridManagementClient>();

				string topicName = context.GenerateName("essubtopic");
				string eventSubscriptionName = context.GenerateName("essubeventsub");

				string scope = $"/subscriptions/{client.SubscriptionId}";

				EventSubscriptionCRUD(client, resourceGroup, topicName, eventSubscriptionName, scope);
			}
		}

		[Fact]
		public void EventSubscriptionCRUDResourceGroupScope()
		{
			using (TestContext context = new TestContext(this))
			{
				ResourceGroup resourceGroup = context.CreateResourceGroup("eg-eventsub-rg-");
				EventGridManagementClient client = context.GetClient<EventGridManagementClient>();

				string topicName = context.GenerateName("esrgtopic");
				string eventSubscriptionName = context.GenerateName("esrgeventsub");

				string scope = $"/subscriptions/{client.SubscriptionId}/resourceGroups/{resourceGroup.Name}";

				EventSubscriptionCRUD(client, resourceGroup, topicName, eventSubscriptionName, scope);
			}
		}

		[Fact]
		public void EventSubscriptionCRUDResourceScope()
		{
			using (TestContext context = new TestContext(this))
			{
				ResourceGroup resourceGroup = context.CreateResourceGroup("eg-eventsub-res-");
				EventGridManagementClient client = context.GetClient<EventGridManagementClient>();
				StorageManagementClient storageClient = context.GetClient<StorageManagementClient>();

				// Setup our target resource
				string storageAccountName = context.GenerateName("egeventsubres");
				StorageAccount storageAccount = storageClient.StorageAccounts.Create(resourceGroup.Name, storageAccountName, new StorageAccountCreateParameters
				{
					Sku = new Microsoft.Azure.Management.Storage.Models.Sku {
						Name = SkuName.StandardLRS
					},
					AccessTier = AccessTier.Hot,
					Kind = Kind.BlobStorage,
					Location = resourceGroup.Location
				});
				Assert.NotNull(storageAccount);

				string topicName = context.GenerateName("esrestopic");
				string eventSubscriptionName = context.GenerateName("esreseventsub");

				string scope = storageAccount.Id;

				EventSubscriptionCRUD(client, resourceGroup, topicName, eventSubscriptionName, scope);
			}
		}

		[Fact]
		public void EventSubscriptionCRUDTopicScope()
		{
			using (TestContext context = new TestContext(this))
			{
				ResourceGroup resourceGroup = context.CreateResourceGroup("eg-eventsub-top-");
				EventGridManagementClient client = context.GetClient<EventGridManagementClient>();

				string triggerTopicName = context.GenerateName("esresparenttopic");

				Topic triggerTopic = client.Topics.CreateOrUpdate(resourceGroup.Name, triggerTopicName, new Topic
				{
					Location = resourceGroup.Location
				});
				Assert.NotNull(triggerTopic);

				string topicName = context.GenerateName("estoptopic");
				string eventSubscriptionName = context.GenerateName("estopeventsub");

				string scope = $"/subscriptions/{client.SubscriptionId}/resourceGroups/{resourceGroup.Name}/providers/Microsoft.EventGrid/topics/{triggerTopicName}";

				EventSubscriptionCRUD(client, resourceGroup, topicName, eventSubscriptionName, scope);
			}
		}

		[Fact(Skip = "List tests are not fully implemented")]
		public void EventSubscriptionListBy()
		{
			using (TestContext context = new TestContext(this))
			{
				ResourceGroup resourceGroup = context.CreateResourceGroup("eg-eventsublist-");
				EventGridManagementClient client = context.GetClient<EventGridManagementClient>();

				//client.EventSubscriptions.ListByResource

				//client.EventSubscriptions.ListGlobalByResourceGroup

				//client.EventSubscriptions.ListGlobalByResourceGroupForTopicType

				//client.EventSubscriptions.ListGlobalBySubscription

				//client.EventSubscriptions.ListGlobalBySubscriptionForTopicType

				//client.EventSubscriptions.ListRegionalByResourceGroup

				//client.EventSubscriptions.ListRegionalByResourceGroupForTopicType

				//client.EventSubscriptions.ListRegionalBySubscription

				//client.EventSubscriptions.ListRegionalBySubscriptionForTopicType
			}
		}

		private void EventSubscriptionCRUD(EventGridManagementClient client, ResourceGroup resourceGroup, 
			string topicName, string eventSubscriptionName, string scope)
		{
			// Create a topic we can use
			Topic topic = client.Topics.CreateOrUpdate(resourceGroup.Name, topicName, new Topic
			{
				Location = resourceGroup.Location
			});
			Assert.NotNull(topic);

			// Create an event subscription with a destination and no filter
			string originalDestinationEndpoint = "https://originaltesturl.azure.com/test";
			string destinationEndpointType = EndpointType.WebHook;
			EventSubscription createEventSub = client.EventSubscriptions.Create(scope, eventSubscriptionName, new EventSubscription
			{
				Destination = new EventSubscriptionDestination
				{
					EndpointType = destinationEndpointType,
					EndpointUrl = originalDestinationEndpoint
				}
			});
			Assert.NotNull(createEventSub);
			Assert.Null(createEventSub.Filter);
			Assert.NotNull(createEventSub.Destination);
			Assert.Equal(destinationEndpointType, createEventSub.Destination.EndpointType);
			Assert.Equal(originalDestinationEndpoint, createEventSub.Destination.EndpointUrl);

			// Get the event subscription
			EventSubscription getEventSub = client.EventSubscriptions.Get(scope, eventSubscriptionName);
			Assert.NotNull(getEventSub);
			Assert.Null(getEventSub.Filter);
			Assert.NotNull(getEventSub.Destination);
			Assert.Equal(destinationEndpointType, getEventSub.Destination.EndpointType);
			Assert.Equal(originalDestinationEndpoint, getEventSub.Destination.EndpointUrl);

			// Update just the destination 
			string newDestinationEndpoint = "https://newtesturl.azure.com/new";
			EventSubscription updateEventSub = client.EventSubscriptions.Update(scope, eventSubscriptionName, new EventSubscriptionUpdateParameters
			{
				Destination = new EventSubscriptionDestination
				{
					EndpointType = EndpointType.WebHook,
					EndpointUrl = newDestinationEndpoint
				}
			});
			Assert.NotNull(updateEventSub);
			Assert.Null(updateEventSub.Filter);
			Assert.NotNull(updateEventSub.Destination);
			Assert.Equal(destinationEndpointType, updateEventSub.Destination.EndpointType);
			Assert.Equal(newDestinationEndpoint, updateEventSub.Destination.EndpointUrl);

			// Update the event subscription with a filter
			string subjectBeginsWithFilter = "newFilter";
			bool isSubjectCaseSensitive = false;
			string singleEventType = "all";
			EventSubscription updateFilteredEventSub = client.EventSubscriptions.Update(scope, eventSubscriptionName, new EventSubscriptionUpdateParameters
			{
				Filter = new EventSubscriptionFilter
				{
					IsSubjectCaseSensitive = isSubjectCaseSensitive,
					IncludedEventTypes = new List<string> { singleEventType },
					SubjectBeginsWith = subjectBeginsWithFilter
				}
			});
			Assert.NotNull(updateFilteredEventSub);
			Assert.NotNull(updateFilteredEventSub.Filter);
			Assert.Equal(isSubjectCaseSensitive, updateFilteredEventSub.Filter.IsSubjectCaseSensitive);
			Assert.Equal(singleEventType, updateFilteredEventSub.Filter.IncludedEventTypes.Single());
			Assert.Equal(subjectBeginsWithFilter, updateFilteredEventSub.Filter.SubjectBeginsWith);
			Assert.NotNull(updateFilteredEventSub.Destination);
			Assert.Equal(destinationEndpointType, updateFilteredEventSub.Destination.EndpointType);
			Assert.Equal(newDestinationEndpoint, updateFilteredEventSub.Destination.EndpointUrl);

			// Get event sub to make sure filter and destination exists
			// Get the event subscription
			EventSubscription getFilteredEventSub = client.EventSubscriptions.Get(scope, eventSubscriptionName);
			Assert.NotNull(getFilteredEventSub);
			Assert.NotNull(getFilteredEventSub.Filter);
			Assert.Equal(isSubjectCaseSensitive, getFilteredEventSub.Filter.IsSubjectCaseSensitive);
			Assert.Equal(singleEventType, getFilteredEventSub.Filter.IncludedEventTypes.Single());
			Assert.Equal(subjectBeginsWithFilter, getFilteredEventSub.Filter.SubjectBeginsWith);
			Assert.NotNull(getFilteredEventSub.Destination);
			Assert.Equal(destinationEndpointType, getFilteredEventSub.Destination.EndpointType);
			Assert.Equal(originalDestinationEndpoint, getFilteredEventSub.Destination.EndpointUrl);

			// Do a dummy update with no payload to make sure nothing changes
			EventSubscription emptyUpdateEventSub = client.EventSubscriptions.Update(scope, eventSubscriptionName, new EventSubscriptionUpdateParameters());
			Assert.NotNull(emptyUpdateEventSub);
			Assert.NotNull(emptyUpdateEventSub.Filter);
			Assert.Equal(isSubjectCaseSensitive, emptyUpdateEventSub.Filter.IsSubjectCaseSensitive);
			Assert.Equal(singleEventType, emptyUpdateEventSub.Filter.IncludedEventTypes.Single());
			Assert.Equal(subjectBeginsWithFilter, emptyUpdateEventSub.Filter.SubjectBeginsWith);
			Assert.NotNull(emptyUpdateEventSub.Destination);
			Assert.Equal(destinationEndpointType, emptyUpdateEventSub.Destination.EndpointType);
			Assert.Equal(originalDestinationEndpoint, emptyUpdateEventSub.Destination.EndpointUrl);

			// Get the full url
			EventSubscriptionFullUrl fullUrl = client.EventSubscriptions.GetFullUrl(scope, eventSubscriptionName);
			Assert.NotNull(fullUrl);
			Assert.NotNull(fullUrl.EndpointUrl);

			// Delete the event subscription
			client.EventSubscriptions.Delete(scope, eventSubscriptionName);
		}
	}
}