//	Checks if Object has been interacted with
if ( position_meeting(mouse_x, mouse_y, id) && mouse_check_button_pressed(mb_left) )
{
	//	Creates brand new textbox WITH dialogue inside
	create_txtbox(text_id);
}
