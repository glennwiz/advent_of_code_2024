package gnipa

import "core:fmt"
import "core:io"
import "core:os"
import "core:strconv"
import "core:strings"

liste :: struct {
	nummers: [dynamic]int,
}

main :: proc() {
	path := "C:/dev/advent_of_code_2024/data/20241"

	//init structs
	først_collone := liste {
		nummers = make([dynamic]int),
	}
	andre_collone := liste {
		nummers = make([dynamic]int),
	}
	defer delete(først_collone.nummers)
	defer delete(andre_collone.nummers)

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

		nums := strings.split(line, "   ")
		if len(nums) != 2 do continue

		if first_num, ok := strconv.parse_int(strings.trim_space(nums[0])); ok {
			append(&først_collone.nummers, first_num)
		}

		delete(nums)

	}

	fmt.println("debug value", først_collone.nummers)
}
