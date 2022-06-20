import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { isEmpty } from 'rxjs/operators';
import { Response } from '../response';
import { User } from './user';
import { UserService } from './user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  isLoading: boolean = false;
  isEmpty: boolean = false;

  constructor(private router: Router, public userService: UserService) { }

  ngOnInit(): void {
  }

  login(): void {
    this.isLoading = true;

    let username = (<HTMLInputElement>document.getElementById("username")).value;

    if (username.length == 0 || username == '' || username == ' ') {
      this.isEmpty = true;
    }

    else {
      let user = new User(username);

      this.userService.login(user).subscribe((response: Response) => {
        if (response.status == 1) {
          this.router.navigate(['/home', response.data]);
        }
      });
    }


  }

}
