﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WAES.Domain.Entities;
using WAES.Infra.CrossCutting.Utilities;

namespace WAES.Domain.Tests.Entities
{
    /// <summary>
    /// Summary description for WAESImageTest
    /// </summary>
    [TestClass]
    public class WAESImageTest
    {
        private WAESImage _waesImage;
        string validImage = @"/9j/4AAQSkZJRgABAQEAYABgAAD/4RECRXhpZgAATU0AKgAAAAgACAESAAMAAAABAAEAAAMBAAUAAAABAAAIegMDAAEAAAABAAAAAFEQAAEAAAABAQAAAFERAAQAAAABAAAOw1ESAAQAAAABAAAOw4dpAAQAAAABAAAIguocAAcAAAgMAAAAbgAAAAAc6gAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABhqAAALGPAAWQAwACAAAAFAAAENCQBAACAAAAFAAAEOSSkQACAAAAAzAwAACSkgACAAAAAzAwAADqHAAHAAAIDAAACMQAAAAAHOoAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAyMDE2OjA3OjI4IDE0OjEwOjAzADIwMTY6MDc6MjggMTQ6MTA6MDMAAAD/4QmcaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wLwA8P3hwYWNrZXQgYmVnaW49J++7vycgaWQ9J1c1TTBNcENlaGlIenJlU3pOVGN6a2M5ZCc/Pg0KPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyI+PHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj48cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0idXVpZDpmYWY1YmRkNS1iYTNkLTExZGEtYWQzMS1kMzNkNzUxODJmMWIiIHhtbG5zOnhtcD0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wLyI+PHhtcDpDcmVhdGVEYXRlPjIwMTYtMDctMjhUMTQ6MTA6MDM8L3htcDpDcmVhdGVEYXRlPjwvcmRmOkRlc2NyaXB0aW9uPjwvcmRmOlJERj48L3g6eG1wbWV0YT4NCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgPD94cGFja2V0IGVuZD0ndyc/Pv/bAEMAAgEBAgEBAgICAgICAgIDBQMDAwMDBgQEAwUHBgcHBwYHBwgJCwkICAoIBwcKDQoKCwwMDAwHCQ4PDQwOCwwMDP/bAEMBAgICAwMDBgMDBgwIBwgMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDP/AABEIANwAxwMBIgACEQEDEQH/xAAfAAABBQEBAQEBAQAAAAAAAAAAAQIDBAUGBwgJCgv/xAC1EAACAQMDAgQDBQUEBAAAAX0BAgMABBEFEiExQQYTUWEHInEUMoGRoQgjQrHBFVLR8CQzYnKCCQoWFxgZGiUmJygpKjQ1Njc4OTpDREVGR0hJSlNUVVZXWFlaY2RlZmdoaWpzdHV2d3h5eoOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4eLj5OXm5+jp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";

        [TestMethod]
        [Description("This test provides validation about trying to persist an instance that its ImageContent property is null")]
        public void ShallNotAcceptNullContent()
        {
            _waesImage = new WAESImage() {

                IdCompare = 1,
                ImageContent = null,
                Side = (int)Constants.ImageSide.Left
            };

            Assert.IsFalse(_waesImage.IsValid());
        }

        [TestMethod]
        [Description("This test provides validation about trying to persist an instance that its IdCompare property is non positive")]
        public void ShallNotAcceptNonPositiveId()
        {
            _waesImage = new WAESImage()
            {

                IdCompare = -1,
                ImageContent = Convert.FromBase64String(validImage),
                Side = (int)Constants.ImageSide.Left
            };

            Assert.IsFalse(_waesImage.IsValid());
        }

        [TestMethod]
        [Description("This test provides validation about trying to persist an instance that its Sie property is invalid")]
        public void ShallNotAcceptInvalidSide()
        {
            _waesImage = new WAESImage()
            {

                IdCompare = 1,
                ImageContent = Convert.FromBase64String(validImage),
                Side = 3
            };

            Assert.IsFalse(_waesImage.IsValid());
        }

        [TestMethod]
        [Description("This test provides validation about trying to persist an instance that all properties are valid")]
        public void ShallAcceptValidProperties()
        {
            _waesImage = new WAESImage()
            {

                IdCompare = 1,
                ImageContent = Convert.FromBase64String(validImage),
                Side = (int)Constants.ImageSide.Left
            };

            Assert.IsTrue(_waesImage.IsValid());
        }
    }
}
