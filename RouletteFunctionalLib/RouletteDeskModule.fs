// Learn more about F# at http://fsharp.net

module RouletteDeskModule
open System

type Result=
    |Win
    |Loss
    |Partial

type Color=
    |Red
    |Black
    |None

let colorToStr (c:Color) : string=
    match c with
    | Color.Red -> "Red"
    | Color.Black -> "Black"
    | Color.None -> "None"

let reds=[1;3;5;7;9;12;14;16;18;19;21;23;25;27;30;32;34;36]
let blacks=[ for i in 1..36 -> i] |> List.filter (fun x -> not (reds |> List.exists (fun y->y=x)))

type Outcome(value:int)=
    member this.Value=value
    member this.Color=
        if (reds |> List.exists(fun x->x=value)) then Red
        else if (blacks |> List.exists(fun x->x=value)) then Black
        else None
    override this.ToString() = "(" + this.Value.ToString() + "," + colorToStr(this.Color) + ")"

let draw () =
    let rand = new Random()
    new Outcome(rand.Next(0,36))

let multipleDraws (n:int)=
    let rand=new Random()
    [for i in 1..n -> new Outcome(rand.Next(0,36))]
