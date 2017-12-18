import { Component, OnInit } from '@angular/core';
import {FormGroup} from "@angular/forms";
import { Router} from "@angular/router";
import {UsersService} from "../../users.service";
import {User} from "../../../../sharded/models/User";
import {ERROR_CODES} from "../../../../sharded/models/ErrorCodes";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})



export class RegisterComponent implements OnInit {

  registerForm : FormGroup = null;

  model = null;

  message = ''

  constructor(private usersService : UsersService, private router: Router ) { }

  ngOnInit() {
    this.model = new User()
  }

  onSubmit() {
    this.usersService.registerUser(this.model).subscribe(
      data => {
        this.message = "Zostałeś pomyślnie zarejstrowany"
        setTimeout((router: Router) => {
          this.router.navigate(['']);
      }, 1000);  //5s
      },
      error => {
        let err_code = error.error.code
        this.message = ERROR_CODES[err_code]
      }
    )
  }

}
