import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service'; 
import { UserDto } from 'src/app/models/userdto';

@Component({
  selector: 'app-protected',
  templateUrl: './protected.component.html',
  styleUrls: ['./protected.component.scss']
})
export class ProtectedComponent implements OnInit {

  userName: string = 'Guest';

  constructor(
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.authService.currentUser$.subscribe((user: UserDto | null) => {
        this.userName = user ? user.displayName : 'Guest';

    });
}


  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
