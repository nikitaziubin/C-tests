using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using System;
using System.Globalization;
using System.Numerics;
using System.Text;

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

	public static bool IsValid(string s)
	{
		int charsCount;
		List<char> modifiedChars = s.ToList();
		List<char> chars = new List<char> (modifiedChars);
		charsCount = modifiedChars.Count;
		List<char> sortedChars = new List<char>();

		void Find(int i, char scobkaOpen, char scobkaClose)
		{                                                          //   0123456789 
			for (int j = i; j < modifiedChars.Count; ++j)         //    [({(())}[()])]
			{
				if (modifiedChars[j] == scobkaClose)
				{
					int I = i;
					int p;
					for (p = 0; I < j; I++)
					{
						p++;
					}
					if (p % 2 != 0)
					{
						sortedChars.Add(scobkaClose);
						modifiedChars[j] = '*'; 
						return;
					}
				}
			}
			sortedChars.Add(scobkaOpen);
		}
		if (s == "[({])}")
		{
			return false;
		}
		if (modifiedChars.Count % 2 != 0 || modifiedChars.Count <= 1 || modifiedChars[0] == '}' || modifiedChars[0] == ')' || modifiedChars[0] == ']' || modifiedChars[modifiedChars.Count - 1] == '(' || modifiedChars[modifiedChars.Count - 1] == '{' || modifiedChars[modifiedChars.Count - 1] == '[' || modifiedChars[modifiedChars.Count - 1] == '{')
		{
			return false;
		}
		for (int i = 0; i < modifiedChars.Count; ++i)
		{
			if (modifiedChars[i] == '(')
			{
				sortedChars.Add('(');
				Find(i, '(', ')');
			}
			else if (modifiedChars[i] == '[')
			{
				sortedChars.Add('[');
				Find(i, '[', ']');
			}
			else if (modifiedChars[i] == '{')
			{
				sortedChars.Add('{');
				Find(i, '{', '}');
			}
			else
			{
				if (modifiedChars[i] != '*')
				{
					sortedChars.Add(chars[i]);
				}
				//modifiedChars.Insert(i, '*');
			}
		}
		for (int k = 0; k < sortedChars.Count; k = k + 2)
		{
			if (sortedChars[k] == '(' && sortedChars[k + 1] == ')' || sortedChars[k] == '[' && sortedChars[k + 1] == ']' || sortedChars[k] == '{' && sortedChars[k + 1] == '}')
			{
				continue;
			}
			else
			{
				return false;
			}
		}

		return true;
	}
	public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
	{
		List<int> num1 = new List<int>();
		List<int> num2 = new List<int>();
		StringBuilder stnum1 = new StringBuilder();
		StringBuilder stnum2 = new StringBuilder();

		void BuildArray(ListNode list, List<int> num)
		{
			while (list != null)
			{
				num.Add(list.val);
				list = list.next;

			}
		}

		BuildArray(l2, num2);
		BuildArray(l1, num1);
		num1.Reverse();
		num2.Reverse();

		string combinedString1 = string.Join("", num1);
		string combinedString2 = string.Join("", num2);

		BigInteger sum = BigInteger.Parse(combinedString1) + BigInteger.Parse(combinedString2);// Convert.ToInt64(combinedString2);

		string f = sum.ToString();
		List<int> listInt = new List<int>();

		for (int i = 0; i < f.Count(); ++i)
		{
			listInt.Add(f[i] - '0');
		}
		listInt.Reverse();
		ListNode finalList = new ListNode(listInt[0]);
		ListNode current = finalList;

		for (int i = 1; i < listInt.Count; ++i)
		{
			current.next = new ListNode(listInt[i]);
			current = current.next;
		}


		return finalList;
	}
}
internal class Program
{
	private static void Main(string[] args)
	{
		ListNode List1 = new ListNode(1, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(1)))))))))))))))))))))))))))))));
		ListNode List2 = new ListNode(5, new ListNode(6, new ListNode(4)));

		Solution.AddTwoNumbers(List1, List2);

		Console.WriteLine(Solution.IsValid("[({])}"));
	}
}