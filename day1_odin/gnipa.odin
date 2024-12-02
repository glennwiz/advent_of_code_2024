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

test_pass :: proc(sl: [3]i32) {

	fmt.println(sl)
	v := sl

	fmt.println(sl)
	fmt.println("--", v[0])
	fmt.println("--", &v[0])
}

test_pass2 :: proc(sl: []i32) {
	fmt.println(sl)
	v := sl

	fmt.println(sl)
	fmt.println("----", v[0])
	fmt.println("----", &v[0])
	fmt.println("----", &v[1])
	fmt.println("----", &v[2])

}


main :: proc() {
	path := "C:/dev/advent_of_code_2024/data/20241"

	s := [3]i32{1, 2, 3}
	fmt.println("-", s[0])
	fmt.println("_", &s[0])
	test_pass(s)

	sl := s[:]
	fmt.println("---", sl[0])
	fmt.println("---", &sl[0])

	test_pass2(sl)

	x: rune
	x = 0b10101010
	fmt.println("-----", size_of(x))
	fmt.println("-----", x)

	first_bit := (x >> 7) & 1
	fmt.println(first_bit)

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

	fmt.println(&slice1[0]) //0x0001
	fmt.println(&først_collone.nummers[0]) //0x0001 

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
