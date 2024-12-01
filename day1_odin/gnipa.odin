package gnipa

import "core:fmt"
import "core:io"
import "core:os"
import "core:slice"
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
		//		fmt.println(line)

		nums := strings.split(line, "   ")
		if len(nums) != 2 do continue

		if first_num, ok := strconv.parse_int(strings.trim_space(nums[0])); ok {
			append(&først_collone.nummers, first_num)
		}

		if sec_num, ok := strconv.parse_int(strings.trim_space(nums[1])); ok {
			append(&andre_collone.nummers, sec_num)
		}


		delete(nums)
	}

	//https://odin-lang.org/docs/overview/#sort-slices
	slice1 := først_collone.nummers[:]
	slice2 := andre_collone.nummers[:]

	slice.sort(slice1)
	slice.sort(slice2)

	{ 	//part1
		total := 0
		counter := 0
		for value1 in slice1 {
			if value1 == slice2[counter] {
				counter = counter + 1
				continue
			}
			if value1 > slice2[counter] {

				res := value1 - slice2[counter]
				total = total + res
			}
			if value1 < slice2[counter] {
				res := slice2[counter] - value1
				total = total + res
			}
			counter = counter + 1
		}
		fmt.println(total)
	}

	{ 	//part2
		sum := 0
		counter := 0

		for value in slice1 {
			local := 0
			for valuex in slice2 {
				if value == valuex {
					local = local + 1
				}
			}
			counter = counter + 1

			temp := value * local
			sum = sum + temp
		}
		fmt.println(sum)
	}
}
