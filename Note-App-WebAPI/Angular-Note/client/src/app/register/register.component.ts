import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  registerForm: FormGroup;
  errorMessage: string | null = null;
  showSuccessToast = false;
  successMessage = '';

  constructor(private authService: AuthService, private router: Router, private fb: FormBuilder) {

    this.registerForm = this.fb.group({
      displayName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  register() {
    if (this.registerForm.valid) {
      this.authService.register(this.registerForm.value).subscribe({
        next: () => {
          this.successMessage = 'Registration successful!';
          this.showSuccessToast = true;
          setTimeout(() => this.showSuccessToast = false, 3000);
          this.registerForm.reset();
          this.router.navigate(['/login']);
        },
        error: (error) => {
          console.error(error);
          this.errorMessage = 'Registration failed. Please try again.';
        },
      });
    } else {
      this.errorMessage = 'Please fill out the form correctly.';
    }
  }
}
