// import { PlayerListComponent } from './../player-list/player-list.component';
import { Player } from './../IPlayer';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-loginform',
  templateUrl: './loginform.component.html',
  styleUrls: ['./loginform.component.css']
})
export class LoginformComponent implements OnInit {
  player: Player;
  name1: string;
  // loginForm: FormGroup
  userName: string;
  loginForm: FormGroup;

  constructor() { }

  ngOnInit(): void {
    this.loginForm = new FormGroup(
      {
        userName: new FormControl()
      }
    );
  }

  // functions go down here.
  onSubmit() {
    console.log(this.loginForm.get('userName').value);
    let extractedName = this.loginForm.get('userName').value;
    console.log(extractedName);
  }

}
