import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router} from "@angular/router";
import {UsersService} from "../../users.service";
import {AuthService} from "../../../../sharded/services/auth.service";
import {User} from "../../../../sharded/models/User";
import {ERROR_CODES} from "../../../../sharded/models/ErrorCodes";
import {AuthToken} from "../../../../sharded/models/AuthToken";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  registerForm : FormGroup = null;

  message : string = ''
  
  model = null;

  constructor(private usersService : UsersService, 
    private authService: AuthService,
    private router: Router) { }

  ngOnInit() {
    this.model = new User()
  }

  onSubmit() {
    this.usersService.loginUser(this.model).subscribe(
        (data: AuthToken) => {
        this.message = "Zostałeś pomyślnie zalogowany"
        this.authService.setToken(data)
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
