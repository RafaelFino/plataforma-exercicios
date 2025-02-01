using cs_string_test.Evaluator;
using cs_string_test.Tester;

var evals = new List<IEvaluator>
{
    new NativeEvaluator(),
    new RootsEvaluator(),
    new RootsV2Evaluator()
};

var tester = new PerformanceTester(evals);

tester.Populate(1000, 5000, 256);
tester.Execute();

