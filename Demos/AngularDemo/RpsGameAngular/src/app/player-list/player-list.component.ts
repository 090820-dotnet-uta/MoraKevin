import { AllPlayers } from './../PlayerList';
import { Component, OnInit } from '@angular/core';
import { Player } from '../IPlayer';

@Component({
  selector: 'app-player-list',
  templateUrl: './player-list.component.html',
  styleUrls: ['./player-list.component.css']
})
export class PlayerListComponent implements OnInit {
  ListOfPlayers: Player[];
  constructor() { }

  ngOnInit(): void {
    this.ListOfPlayers = AllPlayers;
    console.log(AllPlayers);
  }

}
