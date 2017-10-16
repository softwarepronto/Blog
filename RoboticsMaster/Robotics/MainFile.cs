/*
 * The instruction specified:
 *   There is no right or wrong solution as long as code works, but we give bonus points 
 *   for a plain-text explanation on why particular design decisions were made and what 
 *   are the tradeoffs. Put it right into the code in a form of a comment at the 
 *   beginning of the main file. 
 *   
 *   Design Decision 1: there is no need for a main file. This file, mainfile, 
 *   was include per-instructions above out of respect for the product manager.
 *   
 *   Design Decision 2: Units tests were used as "a console application with a test 
 *   method or two" is not the way projects are tested. This is 2000 era development so 
 *   Unit Test are simply more natural. 
 *   
 *   Design Decision 3: I do not write software as a single file. Applications regardless
 *   of size are developed using solutions/projets/assemblies and unit tests. I will
 *   provided both a single file and a full implementation that can be gloned via 
 *   GitHub.com
 *   
 *   Design Decision 4: all design decisions are discussed in the context of where
 *   apply directly since there is no true MainFile. Since this is a bonus question 
 *   explanations will be repeated:
 *   1) Chip is the abstract base class of call chips and Operation method is used
 *      by a Robot to invoke a chip's action
 *       public abstract T[] Operation<T>(T[] data);
 *   2) There is no way to make a generic type T numeric. An Extension method
 *      was created for the object type ObjectExtensions.IsNumericType which
 *      determines if a give type in an array of data is numeric (aka is value one
 *      of byte, int, double, decimal, etc.)
 *   3) With generics we could have a case when an array is say IComparable and contains
 *      mixed numeric types. This cannot be supported easily so it is q requirement that
 *      all data in array is composted of the same numeric type (see extension method
 *      ArrayExtensions.IsHomogeneousNumericType).
 *   4) There is an inconsistency in the designing. ChipOfSorts returns an array and
 *      TotalChip returns scalar. To simplify this the scalar, return an array of length
 *      1 with the 0th value element set to the scalar result.
 *   5) The names provided are not consistent: TotalChip and ChipOfSorts so we put our 
 *      faith in the PM and left the names the same.
 */
