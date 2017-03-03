sound_manager = {}

function sound_manager:init()
    create_lua_behavior(Globals.Instance.gameObject, self, "sound_manager")
    
end

function sound_manager:safe_get_bgm_audio_source()
    if self.bgm_source ~= nil then
        return self.bgm_source
    end

    self.bgm_source = self.gameObject:AddComponent(typeof(UAudioSource))
    return self.bgm_source
end

-- 播放背景音乐
function sound_manager:play_bgm()
    
end

-- 暂停背景音乐
function sound_manager:pause_bgm()
end

-- 停止背景音乐
function sound_manager:stop_bgm()    
end

-- 播放背景环境音乐
function sound_manager:play_bgm_etc()
end

-- 暂停背景环境音乐
function sound_manager:pause_bgm_etc()
end

-- 停止背景环境音乐
function sound_manager:stop_bgm_etc()
end

return sound_manager