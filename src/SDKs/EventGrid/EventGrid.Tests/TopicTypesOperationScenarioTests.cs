using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Management.EventGrid;
using Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.Azure.Management.ResourceManager.Models;
using Xunit;

namespace EventGrid.Tests
{
	public class TopicTypesOperationScenarioTests
	{
		[Fact]
		public void ListGetTopicTypes()
		{
			using (TestContext context = new TestContext(this))
			{
				EventGridManagementClient client = context.GetClient<EventGridManagementClient>();

				// List all topic types
				IEnumerable<TopicTypeInfo> listTopicTypes = client.TopicTypes.List();
				Assert.NotNull(listTopicTypes);
				Assert.True(listTopicTypes.Any());
				foreach(TopicTypeInfo topicType in listTopicTypes)
				{
					Assert.NotNull(topicType.Name);
					Assert.NotNull(topicType.Type);
					Assert.NotNull(topicType.Provider);
				}

				// Get specific topic type
				string topicTypeName = "bob";
				TopicTypeInfo getTopicType = client.TopicTypes.Get(topicTypeName);
				Assert.NotNull(getTopicType);
				Assert.NotNull(getTopicType.Name);
				Assert.NotNull(getTopicType.Type);
				Assert.NotNull(getTopicType.Provider);
			}
		}
	}
}
