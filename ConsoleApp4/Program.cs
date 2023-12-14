using System;

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

		if (c.Length() == 1)
		{
			words.Add(c.ToList());
		}
		else
		{
			for (int i = 0; i < c.Length - 1; ++i)
			{

				leters.Add(c[i]);
				for (int j = i + 1; j < leters.Count + i + 1; j++)
				{
					if (c.Length <= j)
					{
						words.Add(new List<char>(leters));
						leters.Clear();
						break;
					}
					for (int k = 0; k < leters.Length(); ++k)
					{
						if (leters[k] == c[j])
						{
							a = false;
							words.Add(new List<char>(leters));
							leters.Clear();
							break;
						}
					}
					if (a == true)
					{
						leters.Add(c[j]);
					}
					a = true;
				}
			}
		}


		int max = 0;
		foreach (var chars in words)
		{
			if (chars.Count > max)
			{
				max = chars.Count;
			}
		}

		return max;
	}
	public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
	{
		double[] result = new double[nums1.Length + nums2.Length];
		int k = 0;
		for (int i = 0; i < nums1.Length; ++i)
		{
			result[i] = nums1[i];
			k = i;
		}
		if (nums1.Length != 0)
		{
			k++;
		}
		for (int j = 0; j < nums2.Length; ++j)
		{
			result[k] = nums2[j];
			k++;	
		}
		Array.Sort(result);
		if (result.Length % 2 == 0)
		{
			return (result[result.Length / 2] + result[result.Length / 2 - 1]) / 2.0;
		}
		else
		{
			return result[result.Length / 2];
		}

	}
}
internal class Program
{
	private static void Main(string[] args)
	{
		int[] a = new int[] { };
		int[] b = new int[] { 2,3 };

		Console.WriteLine(Solution.FindMedianSortedArrays(a, b));

	}
}