// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using AutoMapper;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    public partial class InvokeAzureComputeMethodCmdlet : ComputeAutomationBaseCmdlet
    {
        protected object CreateImageGetDynamicParameters()
        {
            dynamicParameters = new RuntimeDefinedParameterDictionary();
            var pResourceGroupName = new RuntimeDefinedParameter();
            pResourceGroupName.Name = "ResourceGroupName";
            pResourceGroupName.ParameterType = typeof(string);
            pResourceGroupName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 1,
                Mandatory = true
            });
            pResourceGroupName.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("ResourceGroupName", pResourceGroupName);

            var pImageName = new RuntimeDefinedParameter();
            pImageName.Name = "ImageName";
            pImageName.ParameterType = typeof(string);
            pImageName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 2,
                Mandatory = true
            });
            pImageName.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("ImageName", pImageName);

            var pExpand = new RuntimeDefinedParameter();
            pExpand.Name = "Expand";
            pExpand.ParameterType = typeof(string);
            pExpand.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 3,
                Mandatory = false
            });
            pExpand.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("Expand", pExpand);

            var pArgumentList = new RuntimeDefinedParameter();
            pArgumentList.Name = "ArgumentList";
            pArgumentList.ParameterType = typeof(object[]);
            pArgumentList.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByStaticParameters",
                Position = 4,
                Mandatory = true
            });
            pArgumentList.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("ArgumentList", pArgumentList);

            return dynamicParameters;
        }

        protected void ExecuteImageGetMethod(object[] invokeMethodInputParameters)
        {
            string resourceGroupName = (string)ParseParameter(invokeMethodInputParameters[0]);
            string imageName = (string)ParseParameter(invokeMethodInputParameters[1]);
            string expand = (string)ParseParameter(invokeMethodInputParameters[2]);

            if (!string.IsNullOrEmpty(resourceGroupName) && !string.IsNullOrEmpty(imageName))
            {
                var result = ImagesClient.Get(resourceGroupName, imageName, expand);
                var psObject = new PSImage();
                Mapper.Map<Image, PSImage>(result, psObject);
                WriteObject(psObject);
            }
            else if (!string.IsNullOrEmpty(resourceGroupName))
            {
                var result = ImagesClient.ListByResourceGroup(resourceGroupName);
                var resultList = result.ToList();
                var nextPageLink = result.NextPageLink;
                while (!string.IsNullOrEmpty(nextPageLink))
                {
                    var pageResult = ImagesClient.ListByResourceGroupNext(nextPageLink);
                    foreach (var pageItem in pageResult)
                    {
                        resultList.Add(pageItem);
                    }
                    nextPageLink = pageResult.NextPageLink;
                }
                var psObject = new List<PSImageList>();
                foreach (var r in result)
                {
                    psObject.Add(Mapper.Map<Image, PSImageList>(r));
                }
                WriteObject(psObject);
            }
            else
            {
                var result = ImagesClient.List();
                var resultList = result.ToList();
                var nextPageLink = result.NextPageLink;
                while (!string.IsNullOrEmpty(nextPageLink))
                {
                    var pageResult = ImagesClient.ListNext(nextPageLink);
                    foreach (var pageItem in pageResult)
                    {
                        resultList.Add(pageItem);
                    }
                    nextPageLink = pageResult.NextPageLink;
                }
                var psObject = new List<PSImageList>();
                foreach (var r in result)
                {
                    psObject.Add(Mapper.Map<Image, PSImageList>(r));
                }
                WriteObject(psObject);
            }
        }

    }

    public partial class NewAzureComputeArgumentListCmdlet : ComputeAutomationBaseCmdlet
    {
        protected PSArgument[] CreateImageGetParameters()
        {
            string resourceGroupName = string.Empty;
            string imageName = string.Empty;
            string expand = string.Empty;

            return ConvertFromObjectsToArguments(
                 new string[] { "ResourceGroupName", "ImageName", "Expand" },
                 new object[] { resourceGroupName, imageName, expand });
        }
    }

    [Cmdlet(VerbsCommon.Get, "AzureRmImage", DefaultParameterSetName = "InvokeByDynamicParameters")]
    public partial class GetAzureRmImage : InvokeAzureComputeMethodCmdlet
    {
        public override string MethodName { get; set; }

        protected override void ProcessRecord()
        {
            this.MethodName = "ImageGet";
            base.ProcessRecord();
        }

        public override object GetDynamicParameters()
        {
            dynamicParameters = new RuntimeDefinedParameterDictionary();
            var pResourceGroupName = new RuntimeDefinedParameter();
            pResourceGroupName.Name = "ResourceGroupName";
            pResourceGroupName.ParameterType = typeof(string);
            pResourceGroupName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 1,
                Mandatory = false,
                ValueFromPipelineByPropertyName = true,
                ValueFromPipeline = false
            });
            pResourceGroupName.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("ResourceGroupName", pResourceGroupName);

            var pImageName = new RuntimeDefinedParameter();
            pImageName.Name = "ImageName";
            pImageName.ParameterType = typeof(string);
            pImageName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 2,
                Mandatory = false,
                ValueFromPipelineByPropertyName = true,
                ValueFromPipeline = false
            });
            pImageName.Attributes.Add(new AliasAttribute("Name"));
            pImageName.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("ImageName", pImageName);

            var pExpand = new RuntimeDefinedParameter();
            pExpand.Name = "Expand";
            pExpand.ParameterType = typeof(string);
            pExpand.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 3,
                Mandatory = false,
                ValueFromPipelineByPropertyName = true,
                ValueFromPipeline = false
            });
            pExpand.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("Expand", pExpand);

            return dynamicParameters;
        }
    }
}
