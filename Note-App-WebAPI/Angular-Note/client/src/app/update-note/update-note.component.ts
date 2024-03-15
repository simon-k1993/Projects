import { Component, OnInit } from '@angular/core';
import { NotesService } from '../notes/notes.service';
import { Status } from '../models/noteStatus';
import { Note } from '../models/note';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from '../models/noteCategory';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-update-note',
  templateUrl: './update-note.component.html',
  styleUrls: ['./update-note.component.scss']
})
export class UpdateNoteComponent implements OnInit {
  noteId: number | null = null;
  updateNoteForm: FormGroup;
  statusEnum = Status;
  categoryEnum = Category;
  showErrorToast = false;
  toastMessage = '';
  toastType: 'success' | 'error' = 'error';

  constructor(
    private notesService: NotesService,
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder
  ) {
    this.updateNoteForm = this.fb.group({
      name: ['', Validators.required],
      dueDate: [''],
      description: ['', Validators.required],
      status: [Status.Incomplete, Validators.required],
      category: [Category.Personal, Validators.required]
    });
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        this.noteId = +id;
        this.fetchNote();
      }
    });
  }

  fetchNote(): void {
    if (this.noteId && this.noteId > 0) {
      this.notesService.getNoteById(this.noteId).subscribe({
        next: (note: Note) => {
          this.updateNoteForm.setValue({
            name: note.name,
            dueDate: note.dueDate,
            description: note.description,
            status: this.convertStatusFromString(note.status),
            category: this.convertCategoryFromString(note.category)
          });
          this.showErrorToast = false;
        },
        error: (err) => {
          console.error('Failed to fetch note:', err);
          this.showErrorToast = true;
          this.toastMessage = 'Failed to fetch note. Please check the ID.';
          this.toastType = 'error';
        }
      });
    } else {
      console.error('Valid Note ID is required to fetch a note.');
      this.showErrorToast = true;
      this.toastMessage = 'Valid Note ID is required to fetch a note.';
      this.toastType = 'error';
    }
  }

  updateNote(): void {
    if (this.updateNoteForm.valid && this.noteId) {
      this.notesService.updateNote(this.noteId, this.updateNoteForm.value).subscribe({
        next: () => {
          this.showErrorToast = true;
          this.toastMessage = `Note with ID ${this.noteId} updated successfully.`;
          this.toastType = 'success';
          setTimeout(() => {
            this.showErrorToast = false;
          }, 4000);
        },
        error: (err) => {
          console.error('Update failed:', err);
          this.showErrorToast = true;
          this.toastMessage = `Update failed: Note with ID ${this.noteId} does not exist.`;
          this.toastType = 'error';
          setTimeout(() => {
            this.showErrorToast = false;
          }, 4000);
        }
      });
    } else {
      console.error('Form is not valid');
      this.showErrorToast = true;
      this.toastMessage = 'Form is not valid. Please check your inputs.';
      this.toastType = 'error';
      setTimeout(() => {
          this.showErrorToast = false;
      }, 4000);
    }
  }

  convertStatusFromString(statusString: string): Status {
    switch (statusString) {
      case 'Complete':
        return Status.Complete;
      case 'Incomplete':
        return Status.Incomplete;
      default:
        throw new Error(`Unknown status string: ${statusString}`);
    }
  }

  convertCategoryFromString(categoryString: string): Category {
    switch (categoryString) {
      case 'Work':
        return Category.Work;
      case 'Personal':
        return Category.Personal;
      case 'Urgent':
        return Category.Urgent;
      default:
        throw new Error(`Unknown category string: ${categoryString}`);
    }
  }

  private resetForm(): void {
    this.updateNoteForm.reset({
      status: Status.Incomplete,
      category: Category.Personal
    });
  }
}
