# Histogram - V1

[Codewars URL](https://www.codewars.com/kata/57c6c2e1f8392d982a0000f2)

## Background
A 6-sided die is rolled a number of times and the results are plotted as a character-based histogram.
## Example:
```
    10
    #
    #
7   #
#   #
#   #     5
#   #     #
# 3 #     #
# # #     #
# # # 1   #
# # # #   #
-----------
1 2 3 4 5 6
```
## Task
You will be passed all the dice roll results, and your task is to write the code to return a string representing a histogram, so that when it is printed it has the same format as the example.

## Notes
- There are no trailing spaces on the lines
- All lines (including the last) end with a newline `\n`
- A count is displayed above each bar (unless the count is 0)
- The number of rolls may vary but is always less than 100