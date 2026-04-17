using Solutions.P3800;

namespace Tests.P3800;

[Trait("Problem", "3800+")]
public class Problem3896Tests
{
    [Theory(DisplayName = "3896")]
    [MemberData(nameof(ExamplesMemberData))]
    public void ExamplesTest((int[] nums, int expected) @case)
    {
        var problem = new Problem3896();

        var answer = problem.MinOperations(@case.nums);
        answer.Should().Be(@case.expected);

        var answer2 = problem.MinOperations(@case.nums);
        answer2.Should().Be(@case.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(int[] nums, int expected)> Examples()
    {
        yield return ([1, 2, 3, 4], 3);
        yield return ([5, 6, 7, 8], 0);
        yield return ([4, 4], 1);        
        yield return ([11115, 4776, 2638, 7066, 11689, 13033, 8698, 11252, 11168, 5376, 11670, 6619, 1557, 1721, 8288, 9763, 12242, 3854, 4723, 659, 2176, 1205, 10631, 3266, 435, 4694, 10580, 3920, 5400, 11779, 4970, 6081, 4637, 3317, 11251, 5324, 2246, 9212, 13077, 8148, 7008, 12055, 5286, 9951, 10202, 6727, 3480, 9186, 1269, 2679, 4235, 12309, 13242, 12283, 2283, 11765, 4527, 6125, 4972, 6422, 729, 5904, 3276, 9142, 10221, 11109, 11261, 9386, 11227, 6661, 3836, 13222, 870, 8, 5179, 7999, 3890, 13010, 6996, 1125, 942, 53, 4199, 5063, 5599, 4118, 11931, 10524, 3385, 2938, 8729, 12389, 11272, 11542, 9856, 12168, 12128, 2799, 12531, 7268, 9462, 13381, 11084, 7257, 7724, 10388, 6050, 10113, 11310, 4427, 6823, 13219, 8492, 10689, 11577, 3241, 5064], 350);        
    }
}
