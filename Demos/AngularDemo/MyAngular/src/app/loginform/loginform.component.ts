import { Component, OnInit } from '@angular/core';
import { Player } from '../PlayerClass';
import {FormControl, FormGroup} from '@angular/forms'

@Component({
  selector: 'app-loginform',
  templateUrl: './loginform.component.html',
  styleUrls: ['./loginform.component.css']
})
export class LoginformComponent implements OnInit {
  player: Player;
  loginForm: FormGroup;
  constructor() { }

  ngOnInit(): void {
    this.player = new Player();
    this.player.Name = "null";
    this.loginForm = new FormGroup(
      {
        userName: new FormControl()
      }
    );

  }

  onSubmit(){
    console.log(this.loginForm.get("userName").value);
  }

}
