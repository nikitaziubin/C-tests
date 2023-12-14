using LanguageExt;
using static LanguageExt.Prelude;


public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int val = 0, ListNode next = null)
	{
		this.val = val;
		this.next = next;
	}
}


public class Solution
{
	public static int[] TwoSum(int[] nums, int target)
	{
		for (int i = 0; i < nums.Length; i++)
		{
			for (int j = i + 1; j < nums.Length; j++)
			{
				if (nums[i] + nums[j] == target)
				{
					return new int[] { i, j };
				}
			}
		}
		return new int[0];

	}
	public static bool IsPalindrome(int x)
	{
		if (x < 0)
		{
			return false;
		}
		//List<int> ints = new List<int>();
		int[] ints = new int[x];
		int j = 0;
		while (x != 0)
		{
			ints[j] = x % 10;
			x = x / 10;
			j++;
		}
		//double a = ints.Length() / 2.0;
		//double b = Math.Round(a, MidpointRounding.AwayFromZero);
		for (int i = 0; i < j; i++)
		{
			if (ints[i] != ints[j - 1 - i])
			{
				return false;
			}
		}
		return true;
	}
	public static int LengthOfLongestSubstring(string s)
	{
		char[] c = s.ToCharArray();
		List<char> leters = new List<char>();
		List<List<char>> words = new List<List<char>>();
		bool a = true;
		for (int i = 0; i < c.Length; ++i)
		{
			//if (i == c.Length())
			//{
			//	return 1;
			//}
			leters.Add(c[i]);
			for (int j = i + 1; j < c.Length; j++)
			{
				if (c[i] != c[j])
				{
					for (int k = 0; k < leters.Length(); ++k)
					{
						if (leters[k] == c[j])
						{
							a = false;
							break;
						}
					}
					if (a == true)
					{
						leters.Add(c[j]);
					}
					a = true;
				}
				else
				{
					words.Add(new List<char>(leters));
					leters.Clear();
					break;
				}
			}
		}
		return leters.Length();
	}
}
internal class Program
{
	private static void Main(string[] args)
	{
		Solution.LengthOfLongestSubstring("abcabcbb");

	}
}