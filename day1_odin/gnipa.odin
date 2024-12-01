package gnipa

import "core:fmt"
import "core:io"
import "core:os"
import "core:strings"

main :: proc() {
	path := "C:/dev/advent_of_code_2024/data/20241"

	file, err := os.open(path)
	defer os.close(file)

	if err != nil {
		fmt.println("failed")
		return
	} else {
		fmt.println("success")
	}
	//https://odin-lang.org/news/read-a-file-line-by-line/
	data, ok := os.read_entire_file(path, context.allocator)

	if !ok {return}

	defer delete(data, context.allocator)

	the_text := string(data)
	for line in strings.split_lines_iterator(&the_text) {
		fmt.println(line)
	}


	fmt.println("the beginning")
}
