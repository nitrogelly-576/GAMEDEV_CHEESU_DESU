//	Textbox Parameters
textbox_width = 1408;
textbox_height = 351;
border = 80;
line_sep = 50;

txtb_spr = spr_txtbox;
txtb_img  = 0;
txtb_img_spd = 0; //Speed to be divided by 60 for 60 FPS

line_width = textbox_width - border * 2;

//	Text
page = 0;
page_number = 0;
text[0] = "";
text_length[0] = string_length(text[0]);
draw_char = 0;
text_spd = 1;

setup = false;