﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WAES.Application.ViewModels;
using WAES.Infra.CrossCutting.Utilities;
using WAES.Web.Controllers;

namespace WAES.Web.Tests.Controllers
{
    //http://jpillora.com/base64-encoder/
    //http://blog.stevensanderson.com/2009/06/11/integration-testing-your-aspnet-mvc-application/

    [TestClass]
    public class DiffControllerTest
    {
        private HttpClient client;
        [TestInitialize]
        public void DiffControllerTestInitialize()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:50490/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #region Differente images, but same size
        [TestMethod]
        public async Task CompareRightDifferentOfLeftImageWithSameSizeAsync()
        {

            string _leftImageDifferentOfRightImageSameSize = @"/9j/4AAQSkZJRgABAQEAYABgAAD/4RECRXhpZgAATU0AKgAAAAgACAESAAMAAAABAAEAAAMBAAUAAAABAAAIegMDAAEAAAABAAAAAFEQAAEAAAABAQAAAFERAAQAAAABAAAOw1ESAAQAAAABAAAOw4dpAAQAAAABAAAIguocAAcAAAgMAAAAbgAAAAAc6gAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABhqAAALGPAAWQAwACAAAAFAAAENCQBAACAAAAFAAAEOSSkQACAAAAAzAwAACSkgACAAAAAzAwAADqHAAHAAAIDAAACMQAAAAAHOoAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAyMDE2OjA3OjI4IDE0OjEwOjAzADIwMTY6MDc6MjggMTQ6MTA6MDMAAAD/4QmcaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wLwA8P3hwYWNrZXQgYmVnaW49J++7vycgaWQ9J1c1TTBNcENlaGlIenJlU3pOVGN6a2M5ZCc/Pg0KPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyI+PHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj48cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0idXVpZDpmYWY1YmRkNS1iYTNkLTExZGEtYWQzMS1kMzNkNzUxODJmMWIiIHhtbG5zOnhtcD0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wLyI+PHhtcDpDcmVhdGVEYXRlPjIwMTYtMDctMjhUMTQ6MTA6MDM8L3htcDpDcmVhdGVEYXRlPjwvcmRmOkRlc2NyaXB0aW9uPjwvcmRmOlJERj48L3g6eG1wbWV0YT4NCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgPD94cGFja2V0IGVuZD0ndyc/Pv/bAEMAAgEBAgEBAgICAgICAgIDBQMDAwMDBgQEAwUHBgcHBwYHBwgJCwkICAoIBwcKDQoKCwwMDAwHCQ4PDQwOCwwMDP/bAEMBAgICAwMDBgMDBgwIBwgMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDP/AABEIANwAxwMBIgACEQEDEQH/xAAfAAABBQEBAQEBAQAAAAAAAAAAAQIDBAUGBwgJCgv/xAC1EAACAQMDAgQDBQUEBAAAAX0BAgMABBEFEiExQQYTUWEHInEUMoGRoQgjQrHBFVLR8CQzYnKCCQoWFxgZGiUmJygpKjQ1Njc4OTpDREVGR0hJSlNUVVZXWFlaY2RlZmdoaWpzdHV2d3h5eoOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4eLj5OXm5+jp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";
            string _rightImageDifferentOfLeftImageSameSize = @"/9j/4AAQSkZJRgABAQEAYABgAAD/4RD2RXhpZgAATU0AKgAAAAgABwMBAAUAAAABAAAIbgMDAAEAAAABAAAAAFEQAAEAAAABAQAAAFERAAQAAAABAAAOw1ESAAQAAAABAAAOw4dpAAQAAAABAAAIduocAAcAAAgMAAAAYgAAAAAc6gAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABhqAAALGPAAWQAwACAAAAFAAAEMSQBAACAAAAFAAAENiSkQACAAAAAzAwAACSkgACAAAAAzAwAADqHAAHAAAIDAAACLgAAAAAHOoAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAyMDE2OjA3OjI4IDE0OjEwOjAzADIwMTY6MDc6MjggMTQ6MTA6MDMAAAD/4QmcaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wLwA8P3hwYWNrZXQgYmVnaW49J++7vycgaWQ9J1c1TTBNcENlaGlIenJlU3pOVGN6a2M5ZCc/Pg0KPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyI+PHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj48cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0idXVpZDpmYWY1YmRkNS1iYTNkLTExZGEtYWQzMS1kMzNkNzUxODJmMWIiIHhtbG5zOnhtcD0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wLyI+PHhtcDpDcmVhdGVEYXRlPjIwMTYtMDctMjhUMTQ6MTA6MDM8L3htcDpDcmVhdGVEYXRlPjwvcmRmOkRlc2NyaXB0aW9uPjwvcmRmOlJERj48L3g6eG1wbWV0YT4NCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgPD94cGFja2V0IGVuZD0ndyc/Pv/bAEMAAgEBAgEBAgICAgICAgIDBQMDAwMDBgQEAwUHBgcHBwYHBwgJCwkICAoIBwcKDQoKCwwMDAwHCQ4PDQwOCwwMDP/bAEMBAgICAwMDBgMDBgwIBwgMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDP/AABEIANwAxwMBIgACEQEDEQH/xAAfAAABBQEBAQEBAQAAAAAAAAAAAQIDBAUGBwgJCgv/xAC1EAACAQMDAgQDBQUEBAAAAX0BAgMABBEFEiExQQYTUWEHInEUMoGRoQgjQrHBFVLR8CQzYnKCCQoWFxgZGiUmJygpKjQ1Njc4OTpDREVGR0hJSlNUVVZXWFlaY2RlZmdoaWpzdHV2d3h5eoOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4eLj5OXm5+jp6vHy8/T19vf4+fr/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";

            HttpResponseMessage response = await client.PostAsJsonAsync("v1/diff/" + 2 + "/left", new { Base64Image = _leftImageDifferentOfRightImageSameSize });
            Task<ValidationResultViewModel> modelResult = response.Content.ReadAsAsync<ValidationResultViewModel>(new[] { new JsonMediaTypeFormatter() });
            Assert.AreEqual((int)Constants.PossibleReturns.SUCCESSFULLY_SAVED, modelResult.Result.Result);

      
            response = await client.PostAsJsonAsync("v1/diff/" + 2 + "/right", new { Base64Image = _rightImageDifferentOfLeftImageSameSize });
            modelResult = response.Content.ReadAsAsync<ValidationResultViewModel>(new[] { new JsonMediaTypeFormatter() });
            Assert.AreEqual((int)Constants.PossibleReturns.SUCCESSFULLY_SAVED, modelResult.Result.Result);
            
            response = await client.GetAsync("v1/diff/" + 2);
            modelResult = response.Content.ReadAsAsync<ValidationResultViewModel>(new[] { new JsonMediaTypeFormatter() });
            Assert.AreEqual((int)Constants.PossibleReturns.SAME_SIZE_DIFFERENT, modelResult.Result.Result);
        }
        #endregion
    }


}
