# The Robot Problem

### Introduction
Imagine you need to create a robot that is able to make different kind of operations on numerical arrays. You don't know which operations, but you want your robot to be extensible via _chips_. Plug in a _chip_ for sorting an array and now your robot can sort, plug in another one and it can find max element! Such a smart robot you have. But for now it's just a dream, let's make it come true.

### Task
* Implement a type "Robot" with the following requirements
  * Robot must support pluggable chips that allow him to do different operations on numeric arrays
  * Only one chip can be plugged at a time and robot can't function without a chip
  * Chips can be swapped at runtime, since you have only one robot instance (robots are expensive)
* Robot should have only _two_ functions/methods
  * A function that executes current chip's logic and returns result, it should accept an array and return whatever current chip is returning
  * A function that installs a chip into a robot, it should accept a chip and should not return anything
* Implement _two_ chips
  * "Chip of Sorts" — sorts an array in the order _and_ can have an option to specify ascending or descending type of sorting. (Sorting algorythm is not important, use standard one from any library you want.)
  * "Total Chip" — finds a total sum of all elements of an array
* Add a property to your robot that represents total number of different chips installed through robot's lifetime. It should only count _unique_ chips being installed.
* Write one simple test function that tests logic from 4, you don't have to use any Unit Testing framework, just a simple function would be fine
* Give you robot a name, upload your code to https://gist.github.com and send it over

It's up to you how do design your robot and types. Pay attention to make design simple and intuitive. 

### Bonus
There is no right or wrong solution as long as code works, but we give bonus points for a plain-text explanation on why particular design decisions were made and what are the tradeoffs. Put it right into the code in a form of a comment at the beginning of the main file. 

--

### Instructions

If you are going to use C# and .NET make sure you will define all needed types in _one_ `.cs` file and then just __upload it as a Github Gist__. We don't need `.sln` or `.csproj` files or anything else besides the link to that gist. 

#  ❗️ Please _DO NOT_ comment under this gist.