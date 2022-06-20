import { Component, OnInit, Input } from '@angular/core';
import { Response } from '../../response';
import { Note } from '../note';
import { NotesService } from '../notes.service';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.css']
})
export class NoteComponent implements OnInit {
  @Input() note!: Note;
  isLoading: boolean = false;

  constructor(public noteService: NotesService) { }

  ngOnInit(): void {
  }

  deleteNote(noteId: number): void {
    this.isLoading = true;

    if (confirm("Are you sure you want to delete this note?")) {

      this.noteService.deleteNote(noteId).subscribe((response: Response) => {
        if (response.status == 1) {
          this.isLoading = false;
          location.reload();
        }
      });

    }

  }

}
