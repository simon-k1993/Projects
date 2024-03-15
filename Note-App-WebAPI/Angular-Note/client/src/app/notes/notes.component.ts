import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Note } from '../models/note';
import { NotesService } from './notes.service';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.scss']
})
export class NotesComponent implements OnInit {

  notes: Note[] = [];
  currentPage = 1;
  pageSize = 6;
  canNavigateNext = true;
  searchTerm = new FormControl('');
  showNoNotesToast = false;

  constructor(private router: Router, private noteService: NotesService,private authService: AuthService) {}



    ngOnInit(): void {
      this.authService.currentUser$.subscribe(user => {
        if (user) {
          console.log('User changed:', user);
          this.clearAndFetchNotes();
          this.currentPage = 1;
        } else {
          this.notes = [];
          
        }
      });
    
      this.authService.logoutEvent.subscribe(() => {
        this.notes = [];
        this.currentPage = 1;
      });
    }


  
  fetchNotes(page: number, pageSize: number): void {
    this.noteService.getNotes(page, pageSize).subscribe({
      next: (response) => {
        this.notes = response;
        this.canNavigateNext = response.length === pageSize;
      },
      error: (error) => console.error('Error fetching notes:', error),
    });
  }

  goToPage(page: number): void {
    if (page < 1 || page > this.currentPage && !this.canNavigateNext) return;
    this.currentPage = page;
    this.fetchNotes(this.currentPage, this.pageSize);
   
  }

  goToUpdateNote(noteId: number): void {
    this.router.navigate(['/update', noteId]);
  }

  goToNoteDetails(noteId: number): void {
    this.router.navigate(['/note-details', noteId]);
  }

  deleteNote(noteId: number): void {
    this.noteService.deleteNote(noteId).subscribe({
      next: () => {
        this.notes = this.notes.filter(note => note.id !== noteId);
        if (this.notes.length === 0 && this.currentPage > 1) {
          this.goToPage(this.currentPage - 1);
        }
      },
      error: error => console.error('Error deleting note:', error)
    });
  }

  searchNotes(): void {
    const searchTerm = this.searchTerm.value ? this.searchTerm.value.trim() : '';
    if (searchTerm) {
      this.noteService.searchNotes(searchTerm).subscribe({
        next: (notes) => {
          this.notes = notes;
          this.showNoNotesToast = notes.length === 0;
          if (this.showNoNotesToast) {
            setTimeout(() => this.showNoNotesToast = false, 4000);
          }
        },
        error: (error) => console.error('Error searching notes:', error)
      });
    }
  }


  clearAndFetchNotes(): void {
    this.notes = [];
    this.fetchNotes(this.currentPage, this.pageSize);
  }
}
