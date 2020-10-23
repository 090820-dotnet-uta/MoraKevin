export class Player {
  Name: string;
  Wins: number;
  Losses: number;
  PlayerId = -1;
  constructor(Name: string = '', Wins: number = 0, Losses: number = 0, PlayerId?: number) {
    this.Name = Name;
    this.Wins = Wins;
    this.Losses = Losses;
  }
}
