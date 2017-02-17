local test_hello = class("test_hello")

function test_hello:initialize()
    print("hello")
end

function test_hello:say_hello()
    print("say hello...")
end

return test_hello