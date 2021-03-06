using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace EulerTypes{
	public class Digits{
		private int[] digitList;
			
		public int this[int index]{
			get{
				return this.digitList[index];
			}
			set{
				this.digitList[index] = value;
			}
		}
		
		public int Value(){
			int value = 0;
			for(int i = 0; i < digitList.Length; i++){
				value += digitList[i]*(int)Math.Pow(10, i);
			}
			return value;
		}
		
		public bool Contains(int digit){
			return Array.BinarySearch(digitList, digit) >= 0;
		}
		
		public int Length(){
			return digitList.Length;
		}
		
		public Digits(int numeral){
			digitList = new int[(int)Math.Floor(Math.Log10(numeral)) + 1];
			for(int place = 0; place < digitList.Length; place++){
				digitList[place] = numeral % 10;
				numeral /= 10;
			}
		}
		
		override public string ToString(){
			string stringForm = "";
			for(int i = digitList.Length - 1; i >= 0; i--)
				stringForm += digitList[i];
			return stringForm;
		}
		
		// this function can go out of bounds if you try to excise something that's not in the array
		public void Excise(int remove){
			//Console.WriteLine("Attempting to excise " + remove + " from " + this + ".");
			int[] newDigits = new int[digitList.Length - 1];
			bool skipped = false;
			for(int i = 0; i < digitList.Length; i++){
				if(skipped){
					newDigits[i - 1] = digitList[i];
				} else if(digitList[i] == remove){
					skipped = true;
					continue;
				} else {
					newDigits[i] = digitList[i];
				}
			}
			digitList = newDigits;
			return;
		}
		
		public void Increment(){
			if(digitList.Length == 0){
				Console.WriteLine("ERROR: attempted to increment an empty digit list.");
			}
			digitList[0]++;
			for(int pos = 0; pos < digitList.Length - 1; pos++){
				while(digitList[pos] >= 10){
					digitList[pos] -= 10;
					digitList[pos + 1]++;
				}
			}
			if(digitList.Length == 1 && digitList[0] >= 10){
				int[] newDigits = new int[2];
				newDigits[0] = digitList[0] - 10;
				newDigits[1] = 1;
				digitList = newDigits;
			} else if(digitList[digitList.Length - 1] >= 10){
				int[] newDigits = new int[digitList.Length + 1];
				for(int i = 0; i < digitList.Length; i++)
					newDigits[i] = digitList[i];
				newDigits[newDigits.Length - 2] -= 10;
				newDigits[newDigits.Length - 1] = 1;
				digitList = newDigits;
			}
			return;
		}
	}
}