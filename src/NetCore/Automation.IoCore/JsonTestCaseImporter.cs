using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Automation.DatabaseCore;
using Newtonsoft.Json;
using Automation.IoCore.Utils;
using Microsoft.Extensions.Configuration;

namespace Automation.IoCore
{
    public class JsonTestCaseImporter
    {
        private List<TestsFromJson> _testsFromJson;

        public bool ImportJsonFile(IConfiguration configuration, string path)
        {
            DesirializeJson(path);

            if (_testsFromJson == null)
                return false;

            SaveSuites(configuration);
            SaveTests(configuration);

            return true;
        }

        private void DesirializeJson(string path)
        {
            try
            {
                var text = File.ReadAllText(path);
                _testsFromJson = JsonConvert.DeserializeObject<List<TestsFromJson>>(text);
            }
            catch (FileNotFoundException)
            {
                _testsFromJson = null;
            }
        }

        private void SaveSuites(IConfiguration configuration)
        {
            var suiteNames = _testsFromJson.Select(i => i.TestSuite).ToList();
            var suiteNameSet = new HashSet<string>(suiteNames);
            var db = DbHelpers.OpenDbConnection(configuration);

            // TODO: Fix this

            //foreach (var name in suiteNameSet)
            //{
            //    var inDb = db.Testsuites.FirstOrDefault(i => i.TestsuiteName == name);

            //    // Suite already in db
            //    if (inDb != null)
            //        continue;

            //    // Suite not in db
            //    db.Testsuites.Add(new Testsuite { TestsuiteName = name });
            //    db.SaveChanges();
            //}

            db.Dispose();
        }

        private void SaveTests(IConfiguration configuration)
        {
            var db = DbHelpers.OpenDbConnection(configuration);

            // TODO: Fix this

            //foreach (var item in _testsFromJson)
            //{
            //    var inDb = db.Testcases.FirstOrDefault(i => i.TestcaseName == item.TestName);

            //    // Item already in db
            //    if (inDb != null)
            //        continue;

            //    // Item not in db
            //    var suite = db.Testsuites.FirstOrDefault(i => i.TestsuiteName == item.TestSuite);

            //    if (suite == null)
            //        throw new Exception("TestSuite not found");

            //    var newTest = new Testcase
            //    {
            //        TestcaseName = item.TestName,
            //        BelongsToSuite = suite.TestsuiteId,
            //        TestcaseDescription = item.Decription,
            //        TestSuite = suite
            //    };

            //    db.Testcases.Add(newTest);
            //    db.SaveChanges();
            //}

            db.Dispose();
        }
    }
}