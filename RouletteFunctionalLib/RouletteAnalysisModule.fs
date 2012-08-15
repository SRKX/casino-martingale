module RouletteAnalysisModule
open RouletteDeskModule
open RouletteBetsModule


let computeExpectations (bets:RouletteBet list) =
    let n=100000
    let draws=multipleDraws n
    draws
    |> List.map (fun x-> multipleBetsPayoff(bets,x))
    |> List.average