import { Component, OnInit } from '@angular/core';
import { Player } from '../PlayerClass';
import { AllPlayers } from '../ListOfPlayers';
@Component({
  selector: 'app-player-list',
  templateUrl: './player-list.component.html',
  styleUrls: ['./player-list.component.css']
})
export class PlayerListComponent implements OnInit {
  ListofPlayers: Array<Player>;

  constructor() {}

  ngOnInit(): void {
    // this.ListofPlayers = AllPlayers;
  }

}
