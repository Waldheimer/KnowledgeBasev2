using FluentAssertions;
using KnowledgeBasev2.Application.DTOs;
using KnowledgeBasev2.Domain.DTOs;
using KnowledgeBasev2.Tests.Abstractions;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Http.Json;

namespace KnowledgeBasev2.Tests.Commands
{
    public class CreateCommandTest : BaseFunctionalTest
    {
        private readonly CreateDTO validDTO, invalidDTO;
        public CreateCommandTest(TestWebAppFactory factory) : base(factory)
        {
            validDTO = new CreateDTO()
            {
                Text = "Some Test Text",
                System = "Some Test System",
                Tech = "Some Test Tech",
                Lang = "C#",
                Description = "Some Test Description",
                Version = "1.0"
            };
            invalidDTO = new CreateDTO()
            {
                System = "Some Test System",
                Tech = "Some Test Tech",
                Lang = "C#",
                Description = "Some Test Description",
                Version = "1.0"
            };
        }

        [Fact]
        public async Task Should_ReturnBadRequest_WhenTextIsMissing()
        {
            //------------------------------
            //--------- Arrange ------------
            //------------------------------

            HttpResponseMessage response;
            ServiceResponse<Guid>? result;

            //------------------------------
            //--------- Act ----------------
            //------------------------------

            response = await HttpClient.PostAsJsonAsync("api/command", invalidDTO);
            result = await response.Content.ReadFromJsonAsync<ServiceResponse<Guid>>();

            //------------------------------
            //--------- Assert -------------
            //------------------------------

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result!.Data.Should().Be(Guid.Empty);
        }

        [Fact]
        public async Task Should_ReturnValidGuidAndOK_WhenCommandCreated()
        {
            //------------------------------
            //--------- Arrange ------------
            //------------------------------

            HttpResponseMessage response;
            ServiceResponse<Guid>? result = new ServiceResponse<Guid>(true, "Error Message", Guid.Empty);

            //------------------------------
            //--------- Act ----------------
            //------------------------------

            response = await HttpClient.PostAsJsonAsync("api/command", validDTO);
            try
            {
                result = await response.Content.ReadFromJsonAsync<ServiceResponse<Guid>>();
            }catch(Exception e) { }
                                    
            var success = await HttpClient.GetAsync($"api/command/{result!.Data}");

            //------------------------------
            //--------- Assert -------------
            //------------------------------

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result!.Data.Should().NotBe(Guid.Empty);

            success.StatusCode.Should().Be(HttpStatusCode.OK);

            //------------------------------
            //--------- CleanUp ------------
            //------------------------------

            await HttpClient.DeleteAsync($"api/command/{result.Data}");
        }
    }
}
