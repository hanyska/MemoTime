import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { UsersService } from '../services/users.service';
import { User } from '../models/User';
import { ERROR_CODES } from '../models/ErrorCodes';
import { AuthService } from '../../services/auth.service';
import { Router} from "@angular/router";

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
      data => {
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
