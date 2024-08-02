﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Dtos
{
    public class ErrorDto
    {
        public ErrorDto()
        {
            Errors = new();
        }

        public ErrorDto(string error, bool isShow = false)
        {
            Errors.Add(error);
            IsShow = isShow;
        }

        public ErrorDto(List<string> errors, bool isShow)
        {
            Errors = errors;
            IsShow = isShow;
        }

        public List<string> Errors { get; private set; }
        public bool IsShow { get; private set; }
    }
}
