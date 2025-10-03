///	@param text_id
function scr_game_text(_text_id){

switch(_text_id){
	
	case "object 1":
		scr_text("I am an interactable.");
		scr_text("Clearly this dialog box might be too big to fit into a normal game");
		scr_text("Unless of course you're making a visual novel, but I doubt you'll be doing that.");
		break;
		
	case "object 2":
		scr_text("I am the second interactable.");
		scr_text("I am a maniac");
		scr_text("HAHAHAHHAHAHAHAHAHHAHHAHAHAH");
			scr_option("Why?", "object 2 - why?");
			scr_option("I must leave.", "object 2 - leave");
		break;
		case "object 2 - why?":
		
			break;
			
		case "object 2 - leave":
		
			break;
		
		
	case "object 3":
		scr_text("To be 3 or not to be 3?");
		scr_text("Play Deep Rock Galactic");
		break;

	}
}