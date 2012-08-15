// This file is a script that can be executed with the F# Interactive.  
// It can be used to explore and test the library project.
// Note that script files will not be part of the project build.

#load "RouletteDeskModule.fs"
#load "RouletteBetsModule.fs"
#load "RouletteAnalysisModule.fs"
open RouletteDeskModule
open RouletteBetsModule
open RouletteAnalysisModule

let bet1 = new ColorBet(5.0,Red)
//let outcome=draw()

//let res = bet1.Result(outcome);;

let res = computeExpectations [bet1];;