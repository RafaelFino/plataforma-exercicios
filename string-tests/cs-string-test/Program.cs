﻿using cs_string_test.Evaluator;
using cs_string_test.Tester;

var evals = new List<IEvaluator>
{
    new NativeEvaluator(),
    new RootsEvaluator(),
    new RootsV2Evaluator()
};

var tester = new PerformanceTester(evals);

tester.Populate(100, 1000, 256);
tester.Execute();

