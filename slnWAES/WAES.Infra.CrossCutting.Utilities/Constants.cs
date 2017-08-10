﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAES.Infra.CrossCutting.Utilities
{
    public class Constants
    {
        public enum ImageSide
        {
            Left = 0,
            Right = 1
        }
        public enum PossibleReturns
        {
            [Description("'{0}' file not found.")]
            FILE_NOT_FOUND = 0,
            [Description("Invalid Base64 parameter.")]
            INVALID_BASE64_PARAMETER = 1,
            [Description("There are no files of ID '{0}' to compare.")]
            NO_FILES = 2,
            [Description("Files of ID '{0}' are equal.")]
            EQUAL_FILES = 3,
            [Description("Files of ID '{0}' are differents")]
            DIFFERENT_FILES = 4,
            [Description("Files of ID '{0}' have the same size, but they differ in '{1}' pixels.")]
            SAME_SIZE_DIFFERENT = 5,
            [Description("File of ID '{0}' saved successfully.")]
            SUCCESSFULLY_SAVED = 6,
            [Description("Error trying to save.")]
            ERROR = 7
        }
    }
}
