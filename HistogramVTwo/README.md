# Histogram - V2

[Codewars URL](https://www.codewars.com/kata/5d5f5f25f8bdd3001d6ff70a)

## Background
 A 6-sided die is rolled a number of times and the results are plotted as percentages in a character-based vertical histogram.
## Example:
Data: `[14, 6, 140, 30, 0, 10]`
```
      70%
      ██
      ██
      ██
      ██
      ██
      ██
      ██ 
      ██ 15%
7%    ██ ██
██ 3% ██ ██    5%
------------------
 1  2  3  4  5  6 
```
## Task
You will be passed the dice value frequencies, and your task is to write the code to return a string representing a histogram, so that when it is printed it has the same format as the example.

## Notes
- There are no trailing spaces on the lines
- All lines (including the last) end with a newline `\n`
- The percentage is displayed above each bar except when it is 0%
- When displaying percentages always floor/truncate to the nearest integer
- Less than 1% (but not zero) should be written as `<1%`
- The total number of rolls varies, but won't exceed 1,000
- The bar lengths are scaled so that 100% = 15 x bar characters
- When calculating bar lengths always floor/truncate to the nearest integer
- The bar character is █, which is the Unicode U+2588 char