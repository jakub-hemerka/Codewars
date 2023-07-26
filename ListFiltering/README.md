# List Filtering

[Codewars URL](https://www.codewars.com/kata/53dbd5315a3c69eed20002dd)

In this kata you will create a function that takes a list of non-negative integers and strings and returns a new list with the strings filtered out.

### Example
```cs
ListFilterer.GetIntegersFromList(new List<object>(){1, 2, "a", "b"}) => {1, 2}
ListFilterer.GetIntegersFromList(new List<object>(){1, 2, "a", "b", 0, 15}) => {1, 2, 0, 15}
ListFilterer.GetIntegersFromList(new List<object>(){1, 2, "a", "b", "aasf", "1", "123", 231}) => {1, 2, 231}
```