import { Component, ChangeDetectorRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NotesService } from '../notes/notes.service';
import { Status } from '../models/noteStatus';
import { Category } from '../models/noteCategory';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class NoteCreateComponent {
  noteForm: FormGroup;
  showToast = false;
  toastType: 'success' | 'error' = 'error';
  errorMessage: string = '';
  statusEnum = Status;
  categoryEnum = Category;

  constructor(
    private noteService: NotesService, 
    private cdr: ChangeDetectorRef,
    private router: Router, 
    private fb: FormBuilder
  ) {
    this.noteForm = this.fb.group({
      name: ['', Validators.required],
      dueDate: ['', Validators.required],
      description: ['', Validators.required],
      status: [Status.Incomplete, Validators.required],
      category: [Category.Personal, Validators.required]
    });
  }

  addNote(): void {
    if (this.noteForm.valid) {
      this.noteService.addNote(this.noteForm.value).subscribe({
        next: () => {
          this.displayMessage('Note added successfully', 'success');
          this.router.navigate(['/notes']);
        },
        error: () => {
          this.displayMessage('Error adding note. Please try again.', 'error');
        }
      });
    } else {
      this.displayMessage('All fields are required', 'error');
    }
  }

  private displayMessage(message: string, type: 'success' | 'error'): void {
    this.errorMessage = message;
    this.toastType = type;
    this.showToast = true;
    setTimeout(() => {
      this.showToast = false;
    }, 4000);
    if (type === 'success') {
      this.noteForm.reset({
        status: Status.Incomplete,
        category: Category.Personal
      });
    }
  }
}
