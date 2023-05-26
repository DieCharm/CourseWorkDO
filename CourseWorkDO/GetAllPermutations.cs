namespace CourseWorkDO;

public class GetAllPermutations
{
    public static IList<IList<int>> Permute(int[] nums)
    {
        var list = new List<IList<int>>();
        return DoPermute(nums, 0, nums.Length - 1, list);
    }

    static IList<IList<int>> DoPermute(int[] nums, int start, int end, IList<IList<int>> list)
    {
        if (start == end)
        {
            list.Add(new List<int>(nums));
        }
        else
        {
            for (var i = start; i <= end; i++)
            {
                Swap(ref nums[start], ref nums[i]);
                DoPermute(nums, start + 1, end, list);
                Swap(ref nums[start], ref nums[i]);
            }
        }

        return list;
    }

    static void Swap(ref int a, ref int b)
    {
        (a, b) = (b, a);
    }
}