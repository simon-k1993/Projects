import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject, map } from 'rxjs';
import { LoginDto } from './models/login';
import { RegisterDto } from './models/register';
import { UserDto } from './models/userdto';
import { Router } from '@angular/router';
import { Note } from './models/note';
import { NotesService } from './notes/notes.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private currentUserSubject: BehaviorSubject<UserDto | null>;
  public currentUser$: Observable<UserDto | null>;
  public logoutEvent = new Subject<void>();


  constructor(private http: HttpClient) {
    const storedUser = localStorage.getItem('currentUser');
    this.currentUserSubject = new BehaviorSubject<UserDto | null>(storedUser ? JSON.parse(storedUser) : null);
    this.currentUser$ = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): UserDto | null {
    return this.currentUserSubject.value;
  }

  public getAuthToken(): string | null {
    return localStorage.getItem('auth_token');
  }

  login(loginDto: LoginDto): Observable<UserDto> {
    return this.http.post<UserDto>('http://localhost:5135/api/users/login', loginDto).pipe(
      map(user => {
        localStorage.setItem('auth_token', user.token);
        localStorage.setItem('currentUser', JSON.stringify(user));
        this.currentUserSubject.next(user);
        return user;
      })
    );
  }
  


  logout(): void {
    console.log('Logout initiated');
    localStorage.removeItem('auth_token');
    localStorage.removeItem('currentUser'); 
    this.currentUserSubject.next(null);
    this.logoutEvent.next();

  }

  
  register(registerDto: RegisterDto): Observable<UserDto> {
    return this.http.post<UserDto>('http://localhost:5135/api/users/register', registerDto)
      .pipe(map(user => {

        return user;
      }));
  }

  public clearCurrentUser(): void {
    this.currentUserSubject.next(null);
}


  checkEmailExists(email: string): Observable<boolean> {
    return this.http.get<boolean>(`/api/users/emailexists?email=${email}`);
  }

  getCurrentUser(): Observable<UserDto> {
    return this.http.get<UserDto>(`/api/users/getcurrentuser`);
  }
}   