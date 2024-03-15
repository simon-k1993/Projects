import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Note } from '../models/note';
import { NotesService } from '../notes/notes.service';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search-term',
  templateUrl: './search-term.component.html',
  styleUrls: ['./search-term.component.scss']
})
export class SearchTermComponent implements OnInit {
  searchTerm = new FormControl('');
  searchedNotes: Note[] = [];
  searchInitiated = false;

  constructor(
    private noteService: NotesService, 
    private authService: AuthService, 
    private router: Router
  ) {
    this.authService.currentUser$.subscribe(user => {
      if (!user) {
        this.resetComponentState();
      }
    });
  }

  ngOnInit(): void {
    this.authService.logoutEvent.subscribe(() => {
      this.resetComponentState();
    });
  }

  resetComponentState(): void {
    this.searchedNotes = [];
    this.searchTerm.reset();
    this.searchInitiated = false;
  }

  searchNotes(): void {
    const trimmedTerm = this.searchTerm.value ? this.searchTerm.value.trim() : '';
    if (trimmedTerm) {
      this.searchInitiated = true;
      this.noteService.searchNotes(trimmedTerm).subscribe({
        next: (notes) => {
          this.searchedNotes = notes;
        },
        error: (error) => console.error('Error searching notes:', error)
      });
    }
  }

  goToUpdateNote(noteId: number): void {
        this.router.navigate(['/update', noteId]);
      }
    
      goToNoteDetails(noteId: number): void {
        this.router.navigate(['/note-details', noteId]);
      }
    
      deleteNoteById(noteId: number): void {
        const confirmed = window.confirm('Are you sure you want to delete this note?');
        if (confirmed) {
          this.noteService.deleteNote(noteId).subscribe({
            next: () => {
              this.searchedNotes = this.searchedNotes.filter(note => note.id !== noteId);
            },
            error: error => console.error('Error deleting note:', error)
          });
        }
      }
    }