module RouletteBetsModule
open RouletteDeskModule

[<AbstractClass>]
type RouletteBet(notional:double,odd:double)=
    member this.Notional=notional
    member this.Odd=odd
    abstract member Result : Outcome->Result
    member this.Payoff (o:Outcome)=
        match this.Result (o) with
            | Win -> this.Odd * this.Notional
            | Loss -> - this.Notional
            | Partial -> - (this.Notional / 2.0)

type ColorBet(notional,color:Color)=
    inherit RouletteBet(notional,1.0)
    member this.Color=color
    override this.Result(output) =
        match output with
            | x when x.Color=None->Partial
            | x when x.Color=this.Color -> Win
            | _ -> Loss
    override this.ToString() = "ColorBet(" + colorToStr(this.Color) + "," + this.Notional.ToString() + ")"


let multipleBetsPayoff (bets: RouletteBet list,outcome:Outcome) =
    bets
    |> List.map (fun x -> x.Payoff(outcome))
    |> List.sum