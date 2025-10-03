///	@param text
function scr_text(_text){
	text[page_number] = _text;
	page_number++;
}	//	scr_text("Insert Dialogue Here");

///	@param option
///	@param link_id
function scr_option(_option, _link_id){
	option[option_number] = _option;
	option_link_id[option_number] = _link_id;
	option_number++;
}	//	scr_option("Insert Option Name or Text", "Option ID to be placed");

///	@param text_id
function create_txtbox(_text_id){
	//	Creates brand new textbox WITH dialogue inside for an Object
	with ( instance_create_depth(0, 0, -9999, obj_txtbox) )
	{
		scr_game_text(_text_id);
	}
}