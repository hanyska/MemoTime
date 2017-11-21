import { Component, OnInit } from '@angular/core';
import {UsersService} from "../services/users.service";
import {FormGroup} from "@angular/forms";
import {User} from "../models/User";
import {ERROR_CODES} from "../models/ErrorCodes"

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})



export class RegisterComponent implements OnInit {

  registerForm : FormGroup = null;

  model = null;

  message = ''

  constructor(private usersService : UsersService) { }

  ngOnInit() {
    this.model = new User()
  }

  onSubmit() {
    this.usersService.registerUser(this.model).subscribe(
      data => {
        this.message = "Zostałeś pomyślnie zarejstrowany"
      },
      error => {
        let err_code = error.error.code
        this.message = ERROR_CODES[err_code]
      }
    )
  }

}