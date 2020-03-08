using FluentAssertions;
using Learncafe.TestUtilities;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Learncafe.WebApi.Tests
{

    public class WeatherForecastControllerTest : LearncafeTestBase<LearncafeWebApplicationFactory>
    {
        public WeatherForecastControllerTest([NotNull] LearncafeWebApplicationFactory factory) : base(factory) { }

        //[Fact]
        //public async Task ImportPolicies_ShouldSucceed()
        //{
        //    //Arrange
        //    var client = Factory.CreateClient();

        //    await using var file = File.OpenRead("test_policies.xml");
        //    using var content = new StreamContent(file);
        //    using var formData = new MultipartFormDataContent
        //    {
        //        {content, "files", "test_polices.xml"}
        //    };

        //    //Act
        //    var response = await client.PostAsync("/PoliciesImport", formData)
        //        .ConfigureAwait(false);

        //    //Assert
        //    response.StatusCode.Should().Be(HttpStatusCode.OK);
        //}

        [Fact]
        public async Task WeatherForecast_ShouldReturnOK()
        {
            //Arrange
            var client = Factory.CreateClient();

            //Act
            var response = await client.GetAsync("/WeatherForecast")
                .ConfigureAwait(false);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
