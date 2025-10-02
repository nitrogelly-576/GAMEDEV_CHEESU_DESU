var accept_key = keyboard_check_pressed(vk_space);

textbox_x = camera_get_view_x(view_camera[0]);
textbox_y = camera_get_view_y(view_camera[0] + textbox_height); // Textbox is offset so that is spawns near the bottom of the screen

//	Setup
if (setup == false)
{
	setup = true;
	draw_set_font(global.font_main);
	draw_set_valign(fa_top);
	draw_set_halign(fa_left);
	
	//	Loop Through Pages
	page_number = array_length(text);
	for (var p = 0; p < page_number; p++)
	{
		//	Returns how many Characters based on Current Page and stores in "text_length" array
		text_length[p] = string_length(text[p]);
		
		//	Get X position for textbox
			//	Offset Center (No Character)
			text_x_offset[p] = 256;  
	}
}

//	Typing Text
if (draw_char < text_length[page])
{
	draw_char += text_spd;
	draw_char = clamp(draw_char, 0, text_length[page]); //Makes sure that "draw_char" doesn't go beyond "text_length" value
}

//	Flip Through Pages
if (accept_key)
{
	//	If typing done
	if (draw_char == text_length[page])
	{
		//	Next Page
		if (page < page_number-1)
		{
			page++;
			draw_char = 0;
		}
		else
		{ instance_destroy(obj_txtbox); }  //	Destory Textbox
		
	}
	//	If typing NOT done
	else
	{
		draw_char = text_length[page]
	}
}

