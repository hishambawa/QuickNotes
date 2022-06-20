import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Note } from '../notes/note';
import { NotesService } from '../notes/notes.service';
import { Response } from '../response';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})

export class HomeComponent {

  userId: number = -1;
  notes: Note[] = [];
  newNote: boolean = false;
  isLoading: boolean = false;
  isInitializing: boolean = true;

  constructor(public noteService: NotesService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    this.userId = Number(routeParams.get('userId'));

    this.noteService.getNotes(this.userId).subscribe((response: Response) => {
      if (response.status == 1) {
        this.notes = response.data;
        this.isInitializing = false;
      }
    });
  }

  addNote(): void {
    this.newNote = true;
  }

  saveNote(): void {
    this.isLoading = true;

    let noteTitle = (<HTMLInputElement>document.getElementById("note-title")).innerText;
    let noteContent = (<HTMLInputElement>document.getElementById("note-content")).innerHTML;

    let note = new Note(noteTitle, noteContent, this.userId);

    this.noteService.createNote(note).subscribe((response: Response) => {
      if (response.status == 1) {
        this.isLoading = false;
        this.notes.push(response.data);
        this.newNote = false;
      }
    });

  }

  discardNote(): void {
    this.newNote = false;
  }

}
